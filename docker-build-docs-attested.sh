#!/bin/bash
set -e

if [[ -z "$1" ]]; then
  echo "Usage: $0 <version>"
  echo "Example: $0 x.y.z"
  exit 1
fi

VERSION="$1"
BUILDER="buildkit-container"

if ! docker buildx inspect "$BUILDER" >/dev/null 2>&1; then
  echo "Creating BuildKit builder: $BUILDER"
  docker buildx create --name "$BUILDER" --driver docker-container --use
  docker buildx inspect --bootstrap
else
  docker buildx use "$BUILDER"
fi

echo "Generating the Capella metamodel HTML report"
dotnet run --project Auriga.Reporting -c Release -- --ecore resources/ecore --output HtmlDocs/index.html

echo "pulling latest version of nginxinc/nginx-unprivileged:alpine"
docker pull nginxinc/nginx-unprivileged:alpine

echo "Building and Pushing Docker image with SBOM and provenance for version: $VERSION"
docker buildx build \
  --platform=linux/amd64 \
  -f HtmlDocs/Dockerfile \
  -t stariongroup/auriga.docs:latest \
  -t stariongroup/auriga.docs:$VERSION \
  --sbom=true \
  --provenance=true \
  --push \
  .

echo "Build complete."
echo "Tags: latest, $VERSION"
echo "Provenance attached as image metadata"

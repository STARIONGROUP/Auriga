#!/bin/bash
set -e

if [[ -z "$1" ]]; then
  echo "Usage: $0 <version>"
  echo "Example: $0 x.y.z"
  exit 1
fi

VERSION="$1"

echo "Generating the Capella metamodel HTML report"
dotnet run --project Auriga.Reporting -c Release -- --ecore resources/ecore --output HtmlDocs/index.html

echo "pulling latest version of nginxinc/nginx-unprivileged:alpine"
docker pull nginxinc/nginx-unprivileged:alpine

echo "Building local Docker image for version: $VERSION"
docker build \
  -f HtmlDocs/Dockerfile \
  -t stariongroup/auriga.docs:latest \
  -t stariongroup/auriga.docs:$VERSION \
  .

echo "Build complete."
echo "Tags: latest, $VERSION"

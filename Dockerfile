# syntax=docker/dockerfile:1
#
# Builds the Capella metamodel HTML report and serves it as a static site.
#
#   docker build -t auriga-report .
#   docker run --rm -p 8080:80 auriga-report
#   # then browse http://localhost:8080
#
# Multi-stage: the .NET SDK renders the static HTML from the vendored .ecore files, then a lightweight
# nginx image serves the output. The final image contains only the static site — no .NET runtime.

# --- build stage: render the static HTML report ---
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet run --project Auriga.Reporting -c Release -- \
    --ecore resources/ecore \
    --output /report/index.html

# --- serve stage: static files via nginx ---
FROM nginx:alpine AS serve
COPY --from=build /report /usr/share/nginx/html
EXPOSE 80

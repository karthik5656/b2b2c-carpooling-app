#!/bin/sh
# husky

if [ "$1" = "install" ]; then
  cd "$(dirname "$0")/../.."
  npm exec husky install -- src/app/Carpooling.App/ClientApp/.husky
fi

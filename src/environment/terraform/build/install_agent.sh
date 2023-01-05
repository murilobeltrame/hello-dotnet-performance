#!/bin/sh

apt update
mkdir actions-runner && cd actions-runner
# curl -o actions-runner.tar.gz -L https://github.com/actions/runner/releases/download/v2.299.1/actions-runner-linux-x64-2.299.1.tar.gz
curl -o actions-runner.tar.gz -L ${download_url}
tar xzf ./actions-runner-linux.tar.gz
./config.sh --url https://github.com/murilobeltrame/hello-dotnet-performance --token ${token}
./run.sh
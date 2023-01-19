#!/usr/bin/env bash

runnerpath="/home/${username}/ar"

sudo -i -u ${username} bash <<EOF
mkdir $runnerpath && cd $runnerpath
echo "Download"
curl -o actions-runner.tar.gz -L ${download_url}
echo "Extract"
tar xzf ./actions-runner.tar.gz
EOF

cd $runnerpath
echo "Installing dependencies"
./bin/installdependencies.sh

sudo -i -u ${username} bash <<EOF
cd $runnerpath
echo "Configuring client"
./config.sh --unattended --url https://github.com/murilobeltrame/hello-dotnet-performance --token ${token}
EOF

cd $runnerpath
echo "Install service"
./svc.sh install
echo "Run service"
./svc.sh start

curl -fsSL https://get.docker.com -o get-docker.sh
sh get-docker.sh
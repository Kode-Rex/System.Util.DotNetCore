# StoneAge.System.Utils.DotNetCore

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [GitHub CLI](https://cli.github.com/)

## Installing GitHub CLI

Follow the instructions below for your operating system:

### Windows

```sh
winget install --id GitHub.cli
```

### macOS

```sh
brew install gh
```

### Linux (Debian/Ubuntu)

```sh
type -p curl >/dev/null || sudo apt install curl -y
curl -fsSL https://cli.github.com/packages/githubcli-archive-keyring.gpg | sudo dd of=/usr/share/keyrings/githubcli-archive-keyring.gpg 
sudo chmod go+r /usr/share/keyrings/githubcli-archive-keyring.gpg
echo "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/githubcli-archive-keyring.gpg] https://cli.github.com/packages stable main" | sudo tee /etc/apt/sources.list.d/github-cli.list > /dev/null
sudo apt update
sudo apt install gh -y
```

For more details, visit the [GitHub CLI official installation guide](https://github.com/cli/cli#installation).
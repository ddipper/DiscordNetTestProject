# Discord.Net Test Project

All code and features used here will be available through the Discord.Net Nuget packages
- [Discord.Net](https://www.nuget.org/packages/Discord.Net/)

## Requirements:
I will be using Visual Studio Community 2022 almost exclusively through the series.
The Nuget packages used are:
- [Discord.Net](https://www.nuget.org/packages/Discord.Net/) 3.4.0
- [Microsoft.Extensions.Configuration.Yaml](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Yaml/) 2.0.0-preview2
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/) 6.0.0
- [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/) 6.0.0
- [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/) 6.0.0
- [YamlDotNet](https://www.nuget.org/packages/YamlDotNet/) 8.1.2

These packages and versions used may be changed over time as new features are added or bugs are fixed.
### NOTE
The YamlDotNet version used (8.1.2) is important. The latest is bugged and will not work.

## Additional Files Required
config.yml (Must end up in same directory as bot executable)
Sample config.yml contents below:
```
testguild: test_guild_id_here
tokens:
    discord: discord_bot_token_here
```

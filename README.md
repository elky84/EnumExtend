[![Website](https://img.shields.io/website-up-down-green-red/http/shields.io.svg?label=elky-essay)](https://elky84.github.io)
![Made with](https://img.shields.io/badge/made%20with-.NET6-blue.svg)

![GitHub forks](https://img.shields.io/github/forks/elky84/EnumExtend.svg?style=social&label=Fork)
![GitHub stars](https://img.shields.io/github/stars/elky84/EnumExtend.svg?style=social&label=Stars)
![GitHub watchers](https://img.shields.io/github/watchers/elky84/EnumExtend.svg?style=social&label=Watch)
![GitHub followers](https://img.shields.io/github/followers/elky84.svg?style=social&label=Follow)

![GitHub](https://img.shields.io/github/license/mashape/apistatus.svg)
![GitHub repo size in bytes](https://img.shields.io/github/repo-size/elky84/EnumExtend.svg)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/elky84/EnumExtend.svg)

# EnumExtend

## introduce

Easily usable Enum, Newtonsoft.json. (include Description Converter)

### Attribute
```csharp
public enum EnumType
{
    [DescriptionAttribute("Desc0")]
    EnumValue0,

    [DescriptionAttribute("Desc1")]
    EnumValue0,
}
```

### GetDescription
```csharp
enum.GetDescription()
```

or

```csharp
enum.Desc()
```

## github

<https://github.com/elky84/EnumExtend/>

## nuget

<https://www.nuget.org/packages/EnumExtend/>

## Version History

### v1.0.4

added TypesUtil (similar EnumUtil)
Faker.NET Portable Edition
=====
| AppVeyor | Travis | NuGet | GitHub | Codecov |
| :------: | :----: | :---: | :----: | :-----: |
| <a href="https://ci.appveyor.com/project/AdmiringWorm/faker-cs" target="_blank">![AppVeyor](https://img.shields.io/appveyor/ci/AdmiringWorm/faker-cs.svg)</a> | <a href="https://travis-ci.org/AdmiringWorm/Faker.NET.Portable" target="_blank"> ![Travis](https://img.shields.io/travis/AdmiringWorm/Faker.NET.Portable.svg)</a> | <a href="https://www.nuget.org/packages/Faker.Net.Portable" target="_blank">![NuGet](https://img.shields.io/nuget/v/Faker.Net.Portable.svg)</a> | [![GitHub release](https://img.shields.io/github/release/AdmiringWorm/Faker.NET.Portable.svg)](https://github.com/AdmiringWorm/Faker.NET.Portable/releases) | <a href="https://codecov.io/github/AdmiringWorm/Faker.NET.Portable">![codecov.io](https://codecov.io/github/AdmiringWorm/Faker.NET.Portable/coverage.svg)</a>


C# port of the Ruby Faker gem (http://faker.rubyforge.org/) and is used to easily generate fake data: 
names, addresses, phone numbers, etc.

Availabe as a NuGet package <a href="https://nuget.org/packages/Faker.Net.Portable" target="_blank">here</a>.

Get the code via git:

    git clone https://github.com/AdmiringWorm/Faker.NET.Portable.git

Supported version:


    .NET framework 4.0,
    Silverlight 5.0,
    Windows 8,
    Windows Phone 8.1,
    Windows Phone Silverlight 8,
    Xamarin.Android,
    Xamarin.iOS,
    Xamarin.iOS (Classic),
    Mono 3.2.8

## Usage

Add a reference to `Faker.Portable.dll` in you project within Visual Studio.

Start using the Faker methods to generate your random test data.

### Addresses
```C#
Faker.Address.BuildingNumber();         // "65337
Faker.Address.City();                   // "East Omafurt"
Faker.Address.CityPrefix();             // "Port"
Faker.Address.CitySuffix();             // "furt"
Faker.Address.Country();                // "Vietnam"
Faker.Address.CountryCode();            // "MG"
Faker.Address.DefaultCountry();         // "United States"
Faker.Address.Latitude();               // 84.308
Faker.Address.Longitude();              // 11.797
Faker.Address.SecondaryAddress();       // "Apt. 409
Faker.Address.State();                  // "New Mexico"
Faker.Address.StateAbbreviation();      // "AL"
Faker.Address.StreetAddress();          // "17297 Gerry Ports"
Faker.Address.StreetAddress(
       bool includeSecondaryAddress);   // "4345 Eloy Skyway Apt. 349"
Faker.Address.StreetName();             // "Lockman Parkways"
Faker.Address.StreetSuffix();           // "Lodge"
Faker.Address.TimeZone();               // "America/La_Paz"
Faker.Address.ZipCode();                // "14309"
```

### App
```C#
Faker.App.Author();                     // "Hartmann LLC"
Faker.App.Name();                       // "Flixflex"
Faker.App.Version();                    // "0.8.6"
```

### Avatar
```C#
Faker.Avatar.Image(
        string slug,
        string size,
        ImageFormat format,
        string set)             // "http://robohash.org/dictasitsit.png?size=300x300&set=set1"
```
![](http://robohash.org/dictasitsit.png?size=300x300&set=set1)

### Business
```C#
Faker.Business.CreditCardNumber();      // "1211-1221-1234-2201"
Faker.Business.CreditCardExpiryDate();  // "visa"
Faker.Business.CreditCardType();        // 2019-07-17 15:35:35.731
```

### Company
```C#
Faker.Company.Bullshit();               // "syndicate innovative architectures"
Faker.Company.CatchPhrase();            // "Fundamental stable workforce"
Faker.Company.Logo();                   // "http://pigment.github.io/fake-logos/logos/medium/color/13.png"
Faker.Company.Name();                   // "Parisian-Witting"
Faker.Company.Suffix();                 // "and Sons"
```
![](http://pigment.github.io/fake-logos/logos/medium/color/13.png)

### Internet
```C#
Faker.Internet.DomainName();            // "roberts.us"
Faker.Internet.DomainSuffix();          // "info"
Faker.Internet.DomainWord();            // "mrazmedhurst"
Faker.Internet.Email();                 // "felicia_reinger@brownstroman.info"
Faker.Internet.FreeEmail();             // "adela_murphy@yahoo.com"
Faker.Internet.IPv4Address();           // "107.40.61.129"
Faker.Internet.IPv6Address();           // "5a84:cd5:5e97:b368:6266:30fe:f0e5:5eff"
Faker.Internet.MacAddress(
        string prefix,
        char groupSplit);               // "A8:D9:1B:F2:D5:A2"
Faker.Internet.Password(
        int minLength,
        int maxLength);                 // "2e@0SEu'!&ao:+("
Faker.Internet.Slug(
        string words,
        string glue);                   // "inventore_excepturi"
Faker.Internet.Url();                   // "http://www2.dibbert.net/ernesto"
Faker.Internet.UserName();              // "eino_olson"
```

### Lorem Ipsum
```C#
Faker.Lorem.Characters(int charCount);  // "PIXQAe"
Faker.Lorem.Paragraph();                // "Necessitatibus est soluta est modi. Ut debitis iste provident est eum voluptas ut. Unde aliquid quo excepturi omnis hic fuga consectetur dolores. Provident neque beatae omnis illo eos."
Faker.Lorem.Sentence();                 // "Consectetur beatae et doloremque amet."
```

### Names
```C#
Faker.Name.First();                     // "Kaylie"
Faker.Name.FullName();                  // "Ms. Sallie Murphy III"
Faker.Name.Last();                      // "Braun"
Faker.Name.Prefix();                    // "Ms."
Faker.Name.Suffix();                    // "Jr."
```

### Phone numbers
```C#
Faker.Phone.CellNumber();               // "(581) 147-4247"
Faker.Phone.Extension();                // "3485"
Faker.Phone.Number();                   // "1-331-588-8777 x15811"
Faker.Phone.SubscriberNumber();         // "2424"
```

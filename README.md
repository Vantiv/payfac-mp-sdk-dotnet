[![Build Status](https://travis-ci.org/Vantiv/payfac-mp-sdk-dotnet.svg?branch=13.x)](https://travis-ci.org/Vantiv/payfac-mp-sdk-dotnet)
![Github All Releases](https://img.shields.io/github/downloads/vantiv/payfac-mp-sdk-java/total.svg)
[![GitHub](https://img.shields.io/github/license/vantiv/payfac-mp-sdk-java.svg)](https://github.com/Vantiv/payfac-mp-sdk-java/13.x/LICENSE) [![GitHub issues](https://img.shields.io/github/issues/vantiv/payfac-mp-sdk-java.svg)](https://github.com/Vantiv/payfac-mp-sdk-java/issues)

# payfac-mp-sdk-dotnet

The PayFac Merchant Provisioner SDK is a C# implementation of the [Worldpay](https://developer.worldpay.com/community/ecommerce) PayFac Merchant Provisioner API. This SDK was created to make it as easy as possible to perform operations that allows you to create and update Legal Entities and Sub-merchants, as well as retrieve information about existing Legal Entities and Sub-merchants in near real-time. This SDK utilizes the HTTPS protocol to securely connect to Worldpay. Using the SDK requires coordination with the Vantiv eCommerce team in order to be provided with credentials for accessing our systems.

Each .NET SDK release supports all of the functionality present in the associated PayFac Merchant Provisioner API version (e.g., SDK v14.0.0 supports API v14.0.0). Please see our [documentation](https://developer.worldpay.com/community/ecommerce/pages/documentation) for PayFac Merchant Provisioner API to get more details on what operations are supported.

This SDK is implemented to support the .NET plaform, including C#, VB.NET and Managed C++ and is created by Worldpay. Its intended use is for PayFac API operations with Worldpay.

## Getting Started

These instructions will help you get started with using the SDK.

### Prerequisites

None.

### Setup

1.) To install it, copy PayFacSdkForNet.dll into your Visual Studio references.

2.) You can configure it statically by adding the following section to your project's App.config
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <configSections>
        <sectionGroup name="userSettings" type="System.Configuration.UserSettingsGroup, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">
            <section name="PayFacMpSDK.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" allowExeDefinition="MachineToLocalUser" requirePermission="false"/>
        </sectionGroup>
    </configSections>
    <userSettings>
        <PayFacMpSDK.Properties.Settings>
            <setting name="url" serializeAs="String">
                <value>https://www.testvantivcnp.com/sandbox/payfac</value>
            </setting>
            <setting name="username" serializeAs="String">
                <value>username</value>
            </setting>
            <setting name="password" serializeAs="String">
                <value>password</value>
            </setting>
            <setting name="proxyHost" serializeAs="String">
                <value />
            </setting>
            <setting name="timeout" serializeAs="String">
                <value>5000</value>
            </setting>
            <setting name="printxml" serializeAs="String">
                <value>true</value>
            </setting>
            <setting name="proxyPort" serializeAs="String">
                <value />
            </setting>
            <setting name="neuterXml" serializeAs="String">
                <value>true</value>
            </setting>
        </PayFacMpSDK.Properties.Settings>
    </userSettings>
<startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5"/></startup>
</configuration>

```
Also, you can use a Configuration instance to set the values of the different keys by using Set method. 

Example:

```
Configuration config = new Configuration();
config.Set(username, "myUsername");

```
The different Keys and values which chould be passed are:
```
    
    username = myUsername
    password = myPassword
    url = https://www.testvantivcnp.com/sandbox/payfac
    printxml = true
    neuterXml = false
    proxyHost = myProxyHost
    proxyPort = 7777
```

### Configuration
List of configuration parameters along with their values can be found [here](https://gist.github.com/VantivSDK/8b7dd606230ec65b36eba457df4443de).

## Usage example

Let's try our SDK with the Sandbox, which doesn't require a valid username and password:  

```c#
using System;

namespace PayFacMpSDK
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            string legalEntityId = "201015";
            var request = new AgreementRetrievalRequest();
            request.Configuration.Set("url", "https://www.testvantivcnp.com/sandbox/payfac");
            request.Configuration.Set("printxml", "true");

            var response = request.GetLegalEntityAgreementRequest(legalEntityId);

            var agreements = response.agreements;

            foreach(var agreement in agreements)
            {
                Console.WriteLine("Aggrement Type :" + agreement.legalEntityAgreementType);
                Console.WriteLine("Aggrement Version :" + agreement.agreementVersion);
            }

        } 
    }
}
```

Compile and run this file.  You should see the following result:
~~~
    Case Id:1288791001
~~~

## Versioning
For the versions available, see the [tags on this repository](https://github.com/vantiv/payfac-mp-sdk-java/tags). 

## Changelog
For the list of changes, check out the [changelog](https://github.com/Vantiv/payfac-mp-sdk-dotnet/blob/master/CHANGELOG.md)

## Authors

* [**Charmik Sheth**](https://github.com/Charmik-Sheth)
* [**Kartik Dave**](https://github.com/davekartik24)

See also the list of [contributors](https://github.com/vantiv/payfac-mp-sdk-dotnet/contributors) who participated in this project.

## License
This project is licensed under the MIT License - see the [LICENSE](https://github.com/Vantiv/payfac-mp-sdk-dotnet/blob/master/LICENSE) file for details

## Examples
More examples can be found in [Functional and Unit Tests](https://github.com/Vantiv/payfac-mp-sdk-dotnet/tree/master/PayFacMpSDK/PayFacMpSDKTest)

## Support
Please contact [Worldpay eCommerce](https://developer.worldpay.com/products/access/hosted-payment-pages/openapi/other/create) to receive valid merchant credentials in order to run tests successfully or if you require assistance in any way.  Support can also be reached at sdksupport@worldpay.com

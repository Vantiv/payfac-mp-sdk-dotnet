CHANGELOG
---------
## 15.0.1
* **Bug Fix** Fix for returning principal list in legalEntityRetrievalResponse.

## 15.0.0
* **Feature Support for Payfac MP API version 15.0**
Complex element -pciLevel of type pciLevelScore added in legalEntityCreateRequest
Complex element -pciLevel of type pciLevelScore added in legalEntityUpdateRequest
Complex elements-countryOfOrigin,revenueBoost,complianceProducts added in subMerchantCreateRequest
Complex elements-countryOfOrigin,revenueBoost,complianceProducts added in subMerchantUpdateRequest
enum pciLevelScore with enum values 1,2,3,4 and enum complianceProductCode with values SAFERPAYMENT,OTHER
countryOfOrigin with type String with min and max length of 3
revenueBoost of type subMerchantRevenueBoostFeature
subMerchantRevenueBoostFeature of type boolean with enabled would be True/false
complianceProducts contain elements with their type:code of type complianceProductCode,name of type string,active of type boolean,activation of type date ,deActivation of type date,complianceStatus of type string,complianceStatusDate of type date

## 14.0.1
* **Bug Fix** Fix for recursive language call.

## 14.0.0
* **Feature** Support for PayFac MP API v14.0

## 13.1.0
* **Feature** Support for Payfac MP API v13.1

## 13.0.4
* **Bug Fix** Fix camelcasing issue for original legal entity id

## 13.0.3
* **Feature** Changed project structure from .NET Framework to .NET Standard 2.0 (.NET Framework builds will require v4.6.1 or newer).
* **Bug Fix** Fixed casting error when using app.config

## 13.0.2
* **Bug Fix** Converted the boolean value from True to true while serializing

## 13.0.1
* **Bug Fix** Fixing loading of Configuration

## 13.0.0
* **Feature** Support for PayFac MP API v13.0

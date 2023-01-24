param location string = resourceGroup().location
param uniqueSeed string = '${subscription().subscriptionId}-${resourceGroup().name}'
param uniqueSuffix string = 'reddog-${uniqueString(uniqueSeed)}'
param containerAppsEnvName string = 'cae-${uniqueSuffix}'
param logAnalyticsWorkspaceName string = 'log-${uniqueSuffix}'
param appInsightsName string = 'appi-${uniqueSuffix}'

param appsServiceDockerImageName string = 'contosostoreacr.azurecr.io/contosostore-apps:latest'
param booksServiceDockerImageName string = 'contosostoreacr.azurecr.io/contosostore-apps:latest'
param moviesServiceDockerImageName string = 'contosostoreacr.azurecr.io/contosostore-apps:latest'

module containerAppsEnvModule 'modules/container-apps/capps-env.bicep' = {
  name: '${deployment().name}--containerAppsEnv'
  params: {
    location: location
    containerAppsEnvName: containerAppsEnvName
    logAnalyticsWorkspaceName: logAnalyticsWorkspaceName
    appInsightsName: appInsightsName
  }
}

module appsServiceModule 'modules/container-apps/apps-service.bicep' = {
  name: '${deployment().name}--apps-service'
  dependsOn: [
    containerAppsEnvModule
  ]

  params: {
    location: location
    containerAppsEnvName: containerAppsEnvModule.outputs.name
    dockerImage: appsServiceDockerImageName
  }
}

module booksServiceModule 'modules/container-apps/books-service.bicep' = {
  name: '${deployment().name}--books-service'
  dependsOn: [
    containerAppsEnvModule
  ]

  params: {
    location: location
    containerAppsEnvName: containerAppsEnvModule.outputs.name
    dockerImage: booksServiceDockerImageName
  }
}

module moviesServiceModule 'modules/container-apps/movies-service.bicep' = {
  name: '${deployment().name}--books-service'
  dependsOn: [
    containerAppsEnvModule
  ]

  params: {
    location: location
    containerAppsEnvName: containerAppsEnvModule.outputs.name
    dockerImage: moviesServiceDockerImageName
  }
}

output urls array = [
  'UI: https://reddog.${containerAppsEnvModule.outputs.defaultDomain}'
  'Product: https://reddog.${containerAppsEnvModule.outputs.defaultDomain}/product'
  'Makeline Orders (Redmond): https://reddog.${containerAppsEnvModule.outputs.defaultDomain}/makeline/orders/Redmond'
  'Accounting Order Metrics (Redmond): https://reddog.${containerAppsEnvModule.outputs.defaultDomain}/accounting/OrderMetrics?StoreId=Redmond'
]

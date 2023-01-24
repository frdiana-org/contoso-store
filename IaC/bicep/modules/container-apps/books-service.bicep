@description('The name of the Container Apps environment.')
param containerAppsEnvName string
@description('The location of the Container App.')
param location string
@description('Docker image for the Container App.')
param dockerImage string

resource cappsEnv 'Microsoft.App/managedEnvironments@2022-06-01-preview' existing = {
  name: containerAppsEnvName
}

resource appsService 'Microsoft.App/containerApps@2022-03-01' = {
  name: 'books-service'
  location: location
  properties: {
    managedEnvironmentId: cappsEnv.id
    template: {
      containers: [
        {
          name: 'books-service'
          image: dockerImage
          env: [
          ]
          probes: [
            {
              type: 'readiness'
              httpGet: {
                path: '/probes/ready'
                port: 80
              }
              timeoutSeconds: 30
              successThreshold: 1
              failureThreshold: 10
              periodSeconds: 10
            }
            {
              type: 'startup'
              httpGet: {
                path: '/probes/healthz'
                port: 80
              }
              failureThreshold: 6
              periodSeconds: 10
            }
          ]
        }
      ]
      scale: {
        minReplicas: 0
        rules: []
      }
    }
    configuration: {
      ingress: {
        external: true
        targetPort: 80
      }
      secrets: []
    }
  }
}

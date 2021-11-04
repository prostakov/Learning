OpenAPI test project

DesignFirst generate controllers (run from project folder)

dotnet "/Users/prostakov/.nuget/packages/nswag.msbuild/13.13.2/tools/Net50/dotnet-nswag.dll" openapi2cscontroller /input:open-api.yaml /classname:MyResource /namespace:Com.Example.MyResource /output:Controllers/ResourceController.cs /UseLiquidTemplates:true /AspNetNamespace:"Microsoft.AspNetCore.Mvc" /ControllerBaseClass:"Microsoft.AspNetCore.Mvc.Controller"
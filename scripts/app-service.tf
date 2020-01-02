locals {
  download_url = "https://github.com/r1sharma/cosmos-dotnet-core-todo-app/raw/master/src/todo.1.0.0.nupkg"
}

resource "azurerm_app_service_plan" "main" {
  name                = "${var.prefix}-asp"
  location            = "${azurerm_resource_group.main.location}"
  resource_group_name = "${azurerm_resource_group.main.name}"

  sku {
    tier = "Standard"
    size = "S1"
  }
}

resource "azurerm_app_service" "main" {
  name                = "${var.prefix}-appservice"
  location            = "${azurerm_resource_group.main.location}"
  resource_group_name = "${azurerm_resource_group.main.name}"
  app_service_plan_id = "${azurerm_app_service_plan.main.id}"

  site_config {
    dotnet_framework_version = "v4.0"
    scm_type                 = "None"
  }

  app_settings = {
    WEBSITE_RUN_FROM_ZIP = "${local.download_url}"
  }
}

output "website" {
  value = "https://${azurerm_app_service.main.default_site_hostname}"
}
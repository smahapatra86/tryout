# Configure the Azure provider
terraform {
  required_providers {
    azurerm = {
      version = ">= 2.26"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = var.sample_variable
  location = "westus2"

  # tags = {
  #       Environment = "Terraform Getting Started"
  #       Team = "DevOps"
  #   }
}

resource "azurerm_storage_account" "fromterra" {
  name                     = "satyatfstorage"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "GRS"
}
variable "location" {
  type        = string
  description = "Azure resource location"
  default     = "eastus"
}

variable "admin_username" {
  type        = string
  description = "Admin username for Vms"
  default     = "shazam"
}

variable "admin_password" {
  type        = string
  description = "Admin password for Vms"
  default     = "p4$$w0RD"
}

variable "actions_token" {
  type        = string
  description = "Github Actions token"
}

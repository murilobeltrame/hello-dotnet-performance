output "amd64vm" {
  value = "vm-amd64-${random_pet.random.id}"
}

output "arm64vm" {
  value = "vm-arm64-${random_pet.random.id}"
}

package config

import "os"

func GetObjectStorageBaseUrl() string {
	return os.Getenv("OBJ_STOR_BASE_URL")
}

func GetObjectStorageRegion() string {
	return os.Getenv("OBJ_STOR_REGION")
}

func GetObjectStorageCredentials() (string, string) {
	return os.Getenv("OBJ_STOR_KEYID"), os.Getenv("OBJ_STOR_KEY")
}

package config

import (
	"github.com/aws/aws-sdk-go/aws"
	"github.com/aws/aws-sdk-go/aws/credentials"
	"science-archive/doc-store-api/internal/api/handlers"
	"science-archive/doc-store-api/internal/application/services"
	corerepositories "science-archive/doc-store-api/internal/core/repositories"
	coreservices "science-archive/doc-store-api/internal/core/serivces"
	"science-archive/doc-store-api/internal/persistence/object_storage/options"
	"science-archive/doc-store-api/internal/persistence/object_storage/repositories"
)

func ConfigureHandlers() *handlers.StorageHandler {
	service := configureServices()
	return handlers.NewStorageHandler(service)
}

func configureServices() coreservices.StorageService {
	repository := configureRepositories()
	return services.NewContentStorageService(repository)
}

func configureRepositories() corerepositories.StorageRepository {
	keyID, key := GetObjectStorageCredentials()

	connOptions := options.ObjectStorageConnectionOptions{
		Config: aws.Config{
			Endpoint:    aws.String(GetObjectStorageBaseUrl()),
			Region:      aws.String(GetObjectStorageRegion()),
			Credentials: credentials.NewStaticCredentials(keyID, key, ""),
		},
	}

	return repositories.NewObjectStorageRepository(connOptions)
}

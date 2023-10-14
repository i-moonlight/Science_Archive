package services

import (
	"github.com/google/uuid"
	"io"
	"science-archive/doc-store-api/internal/core/repositories"
)

type ContentStorageService struct {
	storageRepository repositories.StorageRepository
}

func NewContentStorageService(repository repositories.StorageRepository) *ContentStorageService {
	return &ContentStorageService{
		storageRepository: repository,
	}
}

func (s *ContentStorageService) UploadDocument(file io.Reader) (string, error) {
	id := uuid.New().String()
	return s.storageRepository.UploadDocument(file, id)
}

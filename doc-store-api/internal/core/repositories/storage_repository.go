package repositories

import "io"

type StorageRepository interface {
	UploadDocument(file io.Reader, filename string) (string, error)
}

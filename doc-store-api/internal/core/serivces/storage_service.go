package serivces

import "io"

type StorageService interface {
	UploadDocument(file io.Reader) (string, error)
}

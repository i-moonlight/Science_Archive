package repositories

import (
	"github.com/aws/aws-sdk-go/aws"
	"github.com/aws/aws-sdk-go/aws/session"
	"github.com/aws/aws-sdk-go/service/s3/s3manager"
	"io"
	"science-archive/doc-store-api/internal/persistence/object_storage/options"
)

type ObjectStorageRepository struct {
	options options.ObjectStorageConnectionOptions
}

func NewObjectStorageRepository(connOptions options.ObjectStorageConnectionOptions) *ObjectStorageRepository {
	return &ObjectStorageRepository{
		options: connOptions,
	}
}

func (r *ObjectStorageRepository) UploadDocument(file io.Reader, filename string) (string, error) {
	sess, err := session.NewSession(&r.options.Config)

	if err != nil {
		return "", err
	}

	uploader := s3manager.NewUploader(sess)

	result, err := uploader.Upload(&s3manager.UploadInput{
		Bucket: aws.String("science-archive-storage"),
		Key:    aws.String(filename),
		Body:   file,
	})

	if err != nil {
		return "", err
	}

	return result.Location, nil
}

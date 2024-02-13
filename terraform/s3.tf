resource "aws_s3_account_public_access_block" "bucket-1" {
  block_public_acls   = false
  block_public_policy = false
}

resource "aws_s3_bucket_public_access_block" "tracktech-bucket-access" {
  bucket = aws_s3_bucket.tracktech-bucket-1.bucket
  block_public_acls       = false
  block_public_policy     = false
  ignore_public_acls      = false
  restrict_public_buckets = false
}

resource "aws_s3_bucket" "tracktech-bucket-1" {
  bucket = "s3.tracktech-bucket.bucket-1"
}
resource "aws_s3_bucket_ownership_controls" "owner-control-s3-bucket" {
  bucket = aws_s3_bucket.tracktech-bucket-1.id

  rule {
    object_ownership = "BucketOwnerPreferred"
  }
}

resource "aws_s3_bucket_acl" "tracktech-bucket-acl" {
  depends_on = [
    aws_s3_bucket_ownership_controls.owner-control-s3-bucket,
    aws_s3_bucket_public_access_block.tracktech-bucket-access,
  ]

  bucket = aws_s3_bucket.tracktech-bucket-1.id
  acl    = "public-read-write"
}

variable "s3_folders" {
  type        = list(string)
  description = "The list of S3 folders to create"
  default     = ["anomaly_images", "asset_images"]
}

resource "aws_s3_object" "images_folder" {
    count   = "${length(var.s3_folders)}"
    bucket = aws_s3_bucket.tracktech-bucket-1.bucket
    key    = "${var.s3_folders[count.index]}/"
}

resource "aws_s3_access_point" "tracktech-s3-access" {
  bucket = aws_s3_bucket.tracktech-bucket-1.bucket
  name   = "tracktech-s3-access"
}

# Voeg een levenscyclusregel toe aan de bucket om objecten naar Glacier Deep Archive te verplaatsen
resource "aws_s3_bucket_lifecycle_configuration" "glacier_bucket_lifecycle" {
  bucket = aws_s3_bucket.tracktech-bucket-1.id

  rule {
    id     = "rule-1"  # Geef een unieke ID op voor de regel
    status = "Enabled"

    filter {
      prefix = "anomaly_images/"  # Voeg de map waar de acties uitgevoerd worden
    }

    transition {
      days          = 1  
      storage_class = "GLACIER"
    }

    expiration {
      days = 3652  # Na 10 jaar wordt deze foto verwijderd
    }
  }

    rule {
    id     = "rule-2"  # Geef een unieke ID op voor de regel
    status = "Enabled"

    filter {
      prefix = "asset_images/"  # Voeg de map waar de acties uitgevoerd worden
    }

    transition {
      days          = 1  
      storage_class = "GLACIER"
    }

    expiration {
      days = 3652  # Na 10 jaar wordt deze foto verwijderd
    }
  }
}

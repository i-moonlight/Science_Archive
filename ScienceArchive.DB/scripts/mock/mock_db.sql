-- Claims
INSERT INTO "claims" ("id", "value", "name", "description")
VALUES
    ('00000000-0000-0000-0000-000000000001', 'claim1', 'Claim 1', 'Description for Claim 1'),
    ('00000000-0000-0000-0000-000000000002', 'claim2', 'Claim 2', 'Description for Claim 2');

-- Roles
INSERT INTO "roles" ("id", "name", "description")
VALUES
    ('00000000-0000-0000-0000-000000000101', 'role1', 'Role 1 Description'),
    ('00000000-0000-0000-0000-000000000102', 'role2', 'Role 2 Description');

-- Roles and claims
INSERT INTO "roles_claims" ("role_id", "claim_id")
VALUES
  ('00000000-0000-0000-0000-000000000101', '00000000-0000-0000-0000-000000000001'),
  ('00000000-0000-0000-0000-000000000101', '00000000-0000-0000-0000-000000000002'),
  ('00000000-0000-0000-0000-000000000102', '00000000-0000-0000-0000-000000000001');

-- Users
INSERT INTO "users" ("id", "name", "email")
VALUES
    ('00000000-0000-0000-0000-000000000201', 'user1', 'user1@example.com'),
    ('00000000-0000-0000-0000-000000000202', 'user2', 'user2@example.com');

-- Users auth data
INSERT INTO "users_auth" ("user_id", "login", "password", "password_salt")
VALUES
    ('00000000-0000-0000-0000-000000000201', 'user1_login', 'hashed_password1', 'salt1'),
    ('00000000-0000-0000-0000-000000000202', 'user2_login', 'hashed_password2', 'salt2');

-- Users and roles
INSERT INTO "users_roles" ("user_id", "role_id")
VALUES
  ('00000000-0000-0000-0000-000000000201', '00000000-0000-0000-0000-000000000101'),
  ('00000000-0000-0000-0000-000000000201', '00000000-0000-0000-0000-000000000102'),
  ('00000000-0000-0000-0000-000000000202', '00000000-0000-0000-0000-000000000101');

-- News
INSERT INTO "news" ("id", "title", "body")
VALUES
    ('00000000-0000-0000-0000-000000000301', 'News Title 1', 'News Body 1'),
    ('00000000-0000-0000-0000-000000000302', 'News Title 2', 'News Body 2');

-- News creation data
INSERT INTO "news_creation" ("news_id", "author_id", "created_timestamp")
VALUES
    ('00000000-0000-0000-0000-000000000301', '00000000-0000-0000-0000-000000000201', '2023-07-19 12:00:00'),
    ('00000000-0000-0000-0000-000000000302', '00000000-0000-0000-0000-000000000202', '2023-07-19 13:00:00');

-- Articles
INSERT INTO "articles" ("id", "title", "description")
VALUES
    ('00000000-0000-0000-0000-000000000401', 'Article Title 1', 'Article Description 1'),
    ('00000000-0000-0000-0000-000000000402', 'Article Title 2', 'Article Description 2');

-- Articles creation data
INSERT INTO "articles_creation" ("article_id", "created_timestamp")
VALUES
    ('00000000-0000-0000-0000-000000000401', '2023-07-19 14:00:00'),
    ('00000000-0000-0000-0000-000000000402', '2023-07-19 15:00:00');

-- Articles authors data
INSERT INTO "articles_authors" ("article_id", "author_id")
VALUES 
  ('00000000-0000-0000-0000-000000000401', '00000000-0000-0000-0000-000000000201'),
  ('00000000-0000-0000-0000-000000000401', '00000000-0000-0000-0000-000000000202'),
  ('00000000-0000-0000-0000-000000000402', '00000000-0000-0000-0000-000000000201'),
  ('00000000-0000-0000-0000-000000000402', '00000000-0000-0000-0000-000000000202');

-- Articles documents
INSERT INTO "articles_documents" ("article_id", "document_path")
VALUES
    ('00000000-0000-0000-0000-000000000401', '/path/to/document1'),
    ('00000000-0000-0000-0000-000000000401', '/path/to/document2'),
    ('00000000-0000-0000-0000-000000000402', '/path/to/document3');

-- Categories
INSERT INTO "categories" ("id", "name")
VALUES
    ('00000000-0000-0000-0000-000000000501', 'Category 1'),
    ('00000000-0000-0000-0000-000000000502', 'Category 2');

-- Articles to categories
INSERT INTO "articles_categories" ("article_id", "category_id")
VALUES
    ('00000000-0000-0000-0000-000000000401', '00000000-0000-0000-0000-000000000501'),
    ('00000000-0000-0000-0000-000000000402', '00000000-0000-0000-0000-000000000501'),
    ('00000000-0000-0000-0000-000000000402', '00000000-0000-0000-0000-000000000502');
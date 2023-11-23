CREATE TABLE IF NOT EXISTS `request_logs` (
  `id`            UUID DEFAULT generateUUIDv4(),
  `timestamp`     DateTime('UTC'),
  `ip`            String,
  `url`           String,
  `user_agent`    String,
  `request_str`   String,
  `response_str`  String
)
ENGINE = MergeTree()
PRIMARY KEY(`id`);
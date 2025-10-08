-- IOテーブルの構造を確認
SELECT
    column_name,
    data_type,
    column_default,
    is_nullable
FROM information_schema.columns
WHERE table_name = 'IO'
ORDER BY ordinal_position;

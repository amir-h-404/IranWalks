# Iran's Walks and Trails

## API

1. Create New ASP.NET Core Web API & Domain Models

### tables

- `Walks` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Name**|**string**|**NO**|
|**Description**|**string**|**NO**|
|**LengthInKM**|**double**|**NO**|
|**WalkImageURI**|**string**|**YES**|
|**RegionId**|**Unique Identifier (GUID)**|**NO**|
|**DifficultyId**|**Unique Identifier (GUID)**|**NO**|

- `Regions` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Code**|**string**|**NO**|
|**Name**|**string**|**NO**|
|**RegionImageURI**|**string**|**YES**|

- `Difficulty` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Name**|**string**|**NO**|

## UI

coming soon...
# Iran's Walks and Trails

## API

1. Create New ASP.NET Core Web API & Domain Models
2. Create New Controller - Regions Controller and CRUD Operations  Action Methods
3. Asynchronous Programming, Repository Pattern and Auto-mapper

### Tables

- `Walks` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Name**|**string**|**NO**|
|**Description**|**string**|**NO**|
|**LengthInKM**|**double**|**NO**|
|**WalkImageUrl**|**string**|**YES**|
|**RegionId**|**Unique Identifier (GUID)**|**NO**|
|**DifficultyId**|**Unique Identifier (GUID)**|**NO**|

- `Regions` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Code**|**string**|**NO**|
|**Name**|**string**|**NO**|
|**RegionImageURI**|**string**|**YES**|

- `Difficulties` table:

|Column Name|Column Type|Nullable|
|---|---|---|
|**Id**|**Unique Identifier (GUID)**|**NO**|
|**Name**|**string**|**NO**|

## UI

coming soon...
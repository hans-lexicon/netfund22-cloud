CREATE TABLE Warnings (
	Id int not null identity primary key,
	NotificationTime datetime2 not null,
	Message nvarchar(max)
)

CREATE TABLE Activities (
	Id int not null identity primary key,
	NotificationTime datetime2 not null,
	Message nvarchar(max)
)
create table users
(
	username varchar(100) not null,
	password varchar(100) not null,
	
	constraint pk_username primary key (username)
);


create table rooms
(
	room_id int identity(1,1) not null,
	room_name varchar(100) not null,
	room_description varchar(200) not null,
	created_by varchar(100) not null,
	created_date datetime not null,	
	
	constraint pk_rooms primary key (room_id),
	constraint fk_rooms_user foreign key (created_by) references users(username)
);

create table room_members
(
	room_id int not null,
	username varchar(100) not null,
	
	constraint pk_room_members primary key (room_id, username),
	constraint fk_room_members_rooms foreign key (room_id) references rooms (room_id),
	constraint fk_room_members_users foreign key (username) references users (username)
);


create table messages
(
	message_id int identity(1,1) not null,
	room_id int not null,
	username varchar(100) not null,
	message varchar(max) not null,
	sent_date datetime not null default(getdate()),
	
	constraint pk_messages primary key (message_id),
	constraint fk_messages_rooms foreign key (room_id) references rooms(room_id),
	constraint fk_messages_users foreign key (username) references users(username)
);

insert into users values ('test_user', 'password');
insert into rooms values ('Hello World', 'Description for Hello World Room', 'test_user', getdate());
insert into messages values ((SELECT @@IDENTITY), 'test_user', 'Hello World', getdate());


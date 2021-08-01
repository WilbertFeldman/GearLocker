create table if not exists public.User (
    id serial primary key,
    username varchar(15) unique,
    isAdmin boolean,
    name varchar(50),
    email varchar(50)
)
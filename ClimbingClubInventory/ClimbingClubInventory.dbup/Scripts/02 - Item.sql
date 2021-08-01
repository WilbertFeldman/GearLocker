create table if not exists public.Item (
    id serial primary key,
    name varchar(50),
    categoryId int references public.Category (id)
)

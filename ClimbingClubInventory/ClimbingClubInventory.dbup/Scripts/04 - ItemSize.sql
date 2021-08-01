create table if not exists public.ItemSize (
    id serial primary key,
    estimatedCost money,
    name varchar(50),
    itemId int references public.item (id)
)
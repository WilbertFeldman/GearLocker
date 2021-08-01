create table if not exists public.RentedItem (
    id serial primary key,
    itemId int references public.ItemSize (id),
    rentalId int references public.Rental (id),
    status smallint,
    userId int references public.User (id),
    quantity int
)
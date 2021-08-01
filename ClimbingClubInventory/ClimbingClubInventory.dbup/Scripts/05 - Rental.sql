create table if not exists public.Rental (
    id serial primary key,
    rentorId int references public.user (id),
    rentorAddress varchar(150),
    rentorStudentIdNumber varchar(9),
    rentorPhoneNumber varchar(15),
    startDate date,
    endDate date,
    renterApproved boolean,
    renterApprovedDate date,
    adminApproved boolean,
    adminApprovedDate date
)
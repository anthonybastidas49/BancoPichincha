/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     02/07/2022 10:43:43                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ACCOUNT') and o.name = 'FK_ACCOUNT_CUSTOMER__CUSTOMER')
alter table ACCOUNT
   drop constraint FK_ACCOUNT_CUSTOMER__CUSTOMER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CUSTOMER') and o.name = 'FK_CUSTOMER_CLIENTE_P_PERSON')
alter table CUSTOMER
   drop constraint FK_CUSTOMER_CLIENTE_P_PERSON
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MOVEMENT') and o.name = 'FK_MOVEMENT_ACCOUNT_M_ACCOUNT')
alter table MOVEMENT
   drop constraint FK_MOVEMENT_ACCOUNT_M_ACCOUNT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ACCOUNT')
            and   name  = 'CUSTOMER_ACCOUNT_FK'
            and   indid > 0
            and   indid < 255)
   drop index ACCOUNT.CUSTOMER_ACCOUNT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ACCOUNT')
            and   type = 'U')
   drop table ACCOUNT
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CUSTOMER')
            and   name  = 'CLIENTE_PERSONA_FK'
            and   indid > 0
            and   indid < 255)
   drop index CUSTOMER.CLIENTE_PERSONA_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CUSTOMER')
            and   type = 'U')
   drop table CUSTOMER
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MOVEMENT')
            and   name  = 'ACCOUNT_MOVEMENT_FK'
            and   indid > 0
            and   indid < 255)
   drop index MOVEMENT.ACCOUNT_MOVEMENT_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MOVEMENT')
            and   type = 'U')
   drop table MOVEMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PERSON')
            and   type = 'U')
   drop table PERSON
go

/*==============================================================*/
/* Table: ACCOUNT                                               */
/*==============================================================*/
create table ACCOUNT (
   ID_ACCOUNT           int identity,
   ID_CUSTOMER          int not null,
   NUMBER               varchar(15)          not null,
   TYPE                 char(1)              not null,
   INITIAL_BALANCE      decimal              not null,
   STATE                char(1)              null,
   LIMIT                decimal              null,
   constraint PK_ACCOUNT primary key nonclustered (ID_ACCOUNT)
)
go

/*==============================================================*/
/* Index: CUSTOMER_ACCOUNT_FK                                   */
/*==============================================================*/
create index CUSTOMER_ACCOUNT_FK on ACCOUNT (
ID_CUSTOMER ASC
)
go

/*==============================================================*/
/* Table: CUSTOMER                                              */
/*==============================================================*/
create table CUSTOMER (
   ID_CUSTOMER          int identity,
   ID_PERSON            int null,
   PASSWORD             varchar(50)          not null,
   STATE                char(1)              not null,
   constraint PK_CUSTOMER primary key nonclustered (ID_CUSTOMER)
)
go

/*==============================================================*/
/* Index: CLIENTE_PERSONA_FK                                    */
/*==============================================================*/
create index CLIENTE_PERSONA_FK on CUSTOMER (
ID_PERSON ASC
)
go

/*==============================================================*/
/* Table: MOVEMENT                                              */
/*==============================================================*/
create table MOVEMENT (
   ID_MOVEMENT          int identity,
   ID_ACCOUNT           int not null,
   DATE                 int null,
   TYPE                 char(1)              null,
   VALUE                decimal              null,
   BALANCE              decimal              null,
   INITIAL_BALANCE decimal null,
   constraint PK_MOVEMENT primary key nonclustered (ID_MOVEMENT)
)
go

/*==============================================================*/
/* Index: ACCOUNT_MOVEMENT_FK                                   */
/*==============================================================*/
create index ACCOUNT_MOVEMENT_FK on MOVEMENT (
ID_ACCOUNT ASC
)
go

/*==============================================================*/
/* Table: PERSON                                                */
/*==============================================================*/
create table PERSON (
   ID_PERSON            int identity,
   NAME                 varchar(100)         not null,
   GENDER               char(1)              not null,
   AGE                  int                  not null,
   DNI                  varchar(10)          not null,
   ADDRESS              varchar(100)         not null,
   PHONE                varchar(15)          not null,
   constraint PK_PERSON primary key nonclustered (ID_PERSON)
)
go

alter table ACCOUNT
   add constraint FK_ACCOUNT_CUSTOMER__CUSTOMER foreign key (ID_CUSTOMER)
      references CUSTOMER (ID_CUSTOMER)
go

alter table CUSTOMER
   add constraint FK_CUSTOMER_CLIENTE_P_PERSON foreign key (ID_PERSON)
      references PERSON (ID_PERSON)
go

alter table MOVEMENT
   add constraint FK_MOVEMENT_ACCOUNT_M_ACCOUNT foreign key (ID_ACCOUNT)
      references ACCOUNT (ID_ACCOUNT)
go


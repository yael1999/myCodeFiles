
#include <stdio.h>
#include <stdbool.h>
#define size 4

typedef struct
{
    int id;
    char customerName[256];
    int creditNum[12];
} customer;

typedef struct
{
    bool available;
    int nightGuests;
    int breakfastGuests;
    customer customer4[4];
} room;

typedef struct
{
    char date[11];       /*0 in the end */
    int breakfastPeople; /* 0-4 people*/
    customer *cp;
    int sleepGuests; /*1-4*/
    room *rp;
} reservation;

typedef struct
{
    room rooms[16];
    reservation reservations[16];
    customer customers[64];
} hotel;

//void showHotelStatus(customer **cpp);

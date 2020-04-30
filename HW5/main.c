#include "func.h";
#include <stdio.h>
#include <string.h>
#define size 4
void showHotelStatus(hotel *h)
{
    room *rp = h->rooms;
    for (int i = 0; i < 16; i++)
    {
        if (!rp->available)
        {
            printf("room number %d is occupied\n", i);
            printf("the booker is: %s\n", h->customers[i].customerName);
            printf("the number of people sleeping in the hotel %d\n", rp->nightGuests);
            printf("the number of people eating breakfast is %d\n", rp->breakfastGuests);
        }
        rp++;
    }
}

void addCustomer(customer *cp, int id, char customerName[256], int creditNum[12])
{
    id = cp->id;
    strcpy(customerName, cp->customerName);
    for (int i = 0; i < 12; i++)
    {
        creditNum[i] = cp->creditNum[i];
    }
}

void checkIfAvailable(hotel *h)
{
}
int checkIfExist(room rooms[16])
{
    room *r = rooms;
    for (int i = 0; i < size * size; i++)
    {
        if (r->available)
        {
            return i;
        }
    }
    return -1;
}

void checkIn(hotel *h)
{
    customer *c = h->customers;
    int customerNum;
    int sleepGuests;
    int breakfastPeople;
    char *str[256] = {0};
    printf("The customers are ");
    for (int i = 0; i < 64; i++)
    {
        printf("%d-%s\n", i, c[i].customerName);
    }
    scanf("I choose customer %d", &customerNum);
    scanf("I want %d people staying in the room", &sleepGuests);
    scanf("I want %d people eating breakfast", &breakfastPeople);
    int numRoom = checkIfExist(h->rooms);
    if (numRoom >= 0)
    {
        h->reservations[numRoom].breakfastPeople = breakfastPeople;
        h->reservations[numRoom].sleepGuests = sleepGuests;
    }
    else
        printf("No room is available ok?????");
}

void checkOut(int num, hotel *h)
{
    room *r = h->rooms + num;
    r->available = true;
}

int main()
{
    hotel california;
    // init customers
    customer customers[64];
    // customer 1
    customer c1;
    char name1[256];
    strcpy(c1.customerName, "Yinon");
    c1.id = 1;
    // cn is garbage;
    // customer 2
    customer c2;
    char name2[256];
    strcpy(c2.customerName, "Yael");
    c2.id = 2;
    // loop over all customers
    for (int i = 0; i < 64; i++)
    {
        if (i < 32)
            california.customers[i] = c1;
        else
            california.customers[i] = c2;
    }
    // init reservations
    customer reservations[16];
    reservation res;
    char date[11] = "20/02/1996";
    res.breakfastPeople = 4;
    res.sleepGuests = 2;
    res.cp = &c1;
    for (int i = 0; i < 16; i++)
        california.reservations[i] = res;
    // init rooms
    room rooms[16];
    room r;
    r.available = false;
    r.nightGuests = 2;
    r.breakfastGuests = 4;
    customer customers4[4] = {c1, c2, c1, c2};
    r.customer4[0] = c1;
    r.customer4[1] = c1;
    r.customer4[2] = c2;
    r.customer4[3] = c2;
    for (int i = 0; i < 16; i++)
        california.rooms[i] = r;
    // run all functions of hotel
    // showHotelStatus(&california);
    checkIn(&california);
    showHotelStatus(&california);

    return 0;
}
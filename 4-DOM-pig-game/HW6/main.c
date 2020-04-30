#include "struct.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
//#include "doctor.h"
#include "patient.h"
#define ERROR 1

// construct a new string in memory

//

doc *doc__new(char *name, char *specielty)
{
    doc *dp = (doc *)malloc(sizeof(doc));
    dp->docName = strdup(name);
    // strcpy(dp->docName,((char *)malloc(strlen(name) * sizeof(char)));
    dp->specialty = strdup(specielty);
    return dp;
}

void doc__free(void *vp)
{
    doc *dp = (doc *)vp;
    free(dp->docName);
    free(dp->specialty);
    free(dp);
}
//
patient *patient__new(char *patientName, int birthYear, doc *treatingD)
{
    patient *pp = (patient *)malloc(sizeof(patient));
    pp->patientName = strdup(patientName);
    pp->birthYear = birthYear;
    pp->treatingD = treatingD;
    return pp;
}

void patient__free(void *vp)
{
    patient *dp = (patient *)vp;
    free(dp->patientName);
    free(dp);
}

void freeList(node *p, void (*freeData)(void *))
{
    node *temp;
    while (p != NULL)
    {
        temp = p;
        p = p->next;
        free(temp);
        freeData(temp->data);
    }
}

void addNode(node **ph, void *data)
{
    node *curr = *ph;
    while (curr != NULL)
    {
        if (curr == data)
        {
            printf("data already exists");
            return;
        }
        curr = curr->next;
    }
    node *temp = (node *)malloc(sizeof(node));
    temp->data = data;
    temp->next = *ph;
    *ph = temp;
}

void *removeNode(node **ph, void *data)
{
    node *current = *ph;
    node *previous = current;
    current = current->next;
    if (previous == NULL)
    {
        return NULL;
    }
    if (previous->data == data)
    {
        *ph = current;
        return previous->data;
    }
    while (current != NULL && current->data != data)
    {
        current = current->next;
        previous = previous->next;
    }
    if (current == NULL)
        return NULL;
    previous->next = current->next;
    free(current);
    return data;
}

void printPatient(void *vp)
{
    patient *p = (patient *)vp;
    printf("%s,%d,%s\n", p->patientName, p->birthYear, p->treatingD->docName);
}
void printDoc(void *vp)
{
    doc *d = (doc *)vp;
    printf("%s,%s\n", d->docName, d->specialty);
}

void printList(node *h, void (*printData)(void *))
{
    if (h == NULL)
    {
        printf("list is empty\n");
    }
    while (h != NULL)
    {
        //  patient *p = (patient *)(h->data);
        printData(h->data); //p in ()
        h = h->next;
    }
}
void printPList(node *h)
{
    printList(h, printPatient);
}
void printDList(node *h)
{
    printList(h, printDoc);
}

void chooseDoctor(node **ph, node *dh)
{ //adding a patient and choosing his treating doctor,pointer to head of patients and pointer to head of doctors list
    char name[256];
    int year;
    int num;
    int i = 0;
    printf("please choose new treating doctor (starting from 0)\n");
    printDList(dh); //printing list of doctors
    scanf(" %d", &num);
    while (i != num && dh != NULL)
    {
        dh = dh->next;
        i++;
    }
    if (dh == NULL)
    {
        return;
    }
    doc *d = (doc *)dh->data;
    printf("enter patient's details\n");
    scanf("%s %d", &name, &year);
    patient *p = patient__new(name, year, d);
    addNode(ph, p);
    printPList(*ph);
}

node *moveForward(node *ph, int num)
{
    int i = 0;
    while (ph != NULL && i != num)
    {
        ph = ph->next;
    }
    return ph;
}

void addATreatingDoctor(node *ph, node *dh) //pointer to head of patients and to head od doctors
{
    int num;
    int i = 0;
    char name[256] = {0};
    char specialty[256] = {0};
    printf("choose a patient (starting from 0):\n");
    printPList(ph);
    scanf("%d", &num);
    ph = moveForward(ph, num);
    printf("choose a doc num (starting from 0):\n", &num);
    printDList(dh);
    scanf("%d", &num);
    dh = moveForward(dh, num);
    patient *p = (patient *)ph->data;
    doc *d = dh->data;
    p->treatingD = d;
}

int chooseAnOption()
{
    int x;
    printf("choose a num -option from the following:\n");
    printf("option num 1 - presenting all patients:\n");
    printf("option num 2 - presenting all doctors:\n");
    printf("option num 3 - add a doctor:\n");
    printf("option num 4 - add a patient and update doctor:\n");
    printf("option num 5 - remove a patient:\n");
    printf("option num 6 - remove a doctor:\n");
    scanf("%d", &x);
    return x;
}

patient *choosePatient(node *pp)
{ // pp pointer to head of patients
    int num;
    printPList(pp);
    printf("choose a patient (starting from 0):");
    scanf("%d", &num);
    moveForward(pp, num);
    patient *p = pp->data;
    return p;
}

doc *chooseDoc(node *dp)
{ // pp pointer to head of docs
    int num;
    printDList(dp);
    printf("choose a doc (starting from 0):");
    scanf("%d", &num);
    moveForward(dp, num);
    doc *d = dp->data;
    return d;
}

int main()
{

    doc *d1 = doc__new("Yinon", "back");
    doc *d2 = doc__new("Yael", "throat");
    patient *p1 = patient__new("Mike", 1990, d1);
    patient *p2 = patient__new("Fiona", 1993, d1);
    node *phead = NULL; //head of patient list
    node *dhead = NULL; //head of doc list
    addNode(&phead, p1);
    addNode(&phead, p2);
    addNode(&dhead, d1);
    addNode(&dhead, d2);
    bool running = true;
    while (running)
    {
        int x = chooseAnOption();
        switch (x)
        {
        case 1:
            printPList(phead);
            break;
        case 2:
            printDList(dhead);
            break;
        case 3:
            addATreatingDoctor(phead, dhead);
            break;
        case 4:
            chooseDoctor(&phead, dhead);
            break;
        case 5:
            removeNode(&phead, choosePatient(phead)); // p
            break;
        case 6:
            removeNode(&dhead, chooseDoc(dhead)); //d
            break;
        default:
            running = false;
            break;
        }
    }
    freeList(dhead, doc__free);
    freeList(phead, patient__free);
    return 0;
}
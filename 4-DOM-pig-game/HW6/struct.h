#include <stdio.h>
#include <stdbool.h>
#define size 4

/*typedef struct docNode
{
    doc *doctor;
    struct docNode *next;
} docNode;

typedef struct patientNode
{
    patient *pat;
    struct patientNode *next;
} patientNode;*/

typedef struct node
{
    void *data;
    struct node *next;
} node;

typedef struct hospital
{
    node *pp;
    node *dp;
} hospital;

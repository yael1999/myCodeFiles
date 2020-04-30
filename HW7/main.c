#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
#include <string.h>
#include "student.h"
#include "prof.h"
#define SIZE_STUDENT 5
#define SIZE_PROFF 3
student *students[SIZE_STUDENT];
prof *proffs[SIZE_PROFF];
int counterS = 0;
int counterP = 0;

void copyByChar(char *from, char *to, size_t s)
{
    for (int i = 0; i < s; i++)
    {
        to[i] = from[i];
    }
}

void *merge(void *a, void *b, size_t lenA, size_t lenB, size_t sizeOfItem, int (*compar)(const void *, const void *))
{
    char *c = (char *)malloc((lenA + lenB) * sizeOfItem);
    char *cOriginal = c;
    char *an = (char *)a;
    char *bn = (char *)b;
    while (lenA >= 1 || lenB >= 1)
    {
        void **va = (void **)an;
        void **vb = (void **)bn;
        if ((lenA >= 1 && lenB == 0) || (lenA >= 1 && lenB >= 1 && compar(*va, *vb) > 0))
        {
            copyByChar(an, c, sizeOfItem);
            /*memcpy(c, an, sizeOfItem);*/
            an += sizeOfItem;
            c += sizeOfItem;
            lenA--;
        }
        else
        {
            copyByChar(bn, c, sizeOfItem);
            /*   memcpy(c, bn, sizeOfItem);*/
            bn += sizeOfItem;
            c += sizeOfItem;
            lenB--;
        }
    }
    return cOriginal;
}
/*void *merge(void *a, void *b, size_t lenA, size_t lenB, size_t sizeOfItem, int (*compar)(const void *, const void *))
{
    char *c = (char *)malloc((lenA + lenB) * sizeOfItem);
    int i = 0;
    char *an = (char *)a;
    char *bn = (char *)b;
    char **who;
    size_t *lenWho;
    while (lenA >= 1 || lenB >= 1)
    {
        if ((lenA >= 1 && lenB == 0) || (lenA >= 1 && lenB >= 1 && compar(an, bn) > 0))
        {
            who = &an;
            lenWho = &lenA;
        }
        else
        {
            who = &bn;
            lenWho = &lenB;
        }
        copyByChar(*who, c, sizeOfItem);
        *who += sizeOfItem;
        c += sizeOfItem;
        *lenWho = *lenWho - 1;
    }
    return c;
}*/
void mergeSort(void *base, size_t numberOfItems, size_t sizeOfItem, int (*compar)(const void *, const void *))
{
    if (numberOfItems <= 1)
        return;
    size_t fcount = numberOfItems / 2;
    char *l = (char *)base;
    char *mid = l + fcount * sizeOfItem;
    mergeSort(l, fcount, sizeOfItem, compar);
    mergeSort(mid, fcount + numberOfItems % 2, sizeOfItem, compar);
    void *temp = merge(l, mid, fcount, fcount + numberOfItems % 2, sizeOfItem, compar);
    copyByChar(temp, base, numberOfItems * sizeOfItem);
    //memcpy(base, temp, numberOfItems * sizeOfItem);
    free(temp);
}

/*void *merge2(void *a, void *b, size_t lenA, size_t lenB, size_t sizeOfItem, int (*compar)(const void *, const void *))
{
    char *c = (char *)malloc((lenA + lenB) * sizeOfItem);
    int i = 0;
    char *an = (char *)a;
    char *bn = (char *)b;
    char **who;
    size_t *lenWho;
    while (lenA >= 1 || lenB >= 1)
    {
        if (lenA >= 1 && lenB >= 1)
        {
            if (compar(an, bn) == 1)
            {
                who = &an;
                lenWho = &lenA;
            }
            else
            {
                who = &bn;
                lenWho = &lenB;
            }
        }
        else
        {
            if (lenA >= 1)
            {
                who = &an;
                lenWho = &lenA;
            }
            else
            {
                who = &bn;
                lenWho = &lenB;
            }
        }
        copyByChar(*who, c, sizeOfItem);
        *who += sizeOfItem;
        c += sizeOfItem;
        *lenWho = *lenWho - 1;
    }
    return c;
}*/
/*void *mergeWrong(void *a, void *b, size_t lenA, size_t lenB, size_t sizeOfItem, int (*compar)(const void *, const void *))
{ //single pointer instead of double
    char *c = (char *)malloc((lenA + lenB) * sizeOfItem);
    int i = 0;
    char *an = (char *)a;
    char *bn = (char *)b;
    char *who;
    size_t lenWho;
    while (lenA >= 1 && lenB >= 1)
    {
        if (compar(an, bn) == 1)
        {
            who = an;
            lenWho = lenA;
        }
        else
        {
            who = bn;
            lenWho = lenB;
        }
        copyByChar(who, c, sizeOfItem);
        who += sizeOfItem;
        c += sizeOfItem;
        lenWho = lenWho - 1;
    }
    return c;
}*/
void printProf(prof *p)
{
    printf("%d %s %d %d %d %d\n", p->id, p->pName, p->age, p->ra, p->minA.min, p->son.seniorOrNot);
}

void printProffArray()
{
    for (int i = 0; i < counterP; i++)
    {
        printProf(proffs[i]);
    }
}
void printStudent(student *s)
{
    printf("%s %d %d %d\n", s->sName, s->id, s->age, s->finalGrade);
}

void printStudentArray()
{
    for (int i = 0; i < counterS; i++)
    {
        printStudent(students[i]);
    }
}

int comparInt(int a, int b)
{
    return b - a;
}

int compareStudentByAge(const void *v1, const void *v2)
{
    student *s1 = (student *)v1;
    student *s2 = (student *)v2;
    return comparInt(s1->age, s2->age);
}

int compareStudentByName(const void *v1, const void *v2)
{
    student *s1 = (student *)v1;
    student *s2 = (student *)v2;
    return strcmp(s2->sName, s1->sName);
}

int compareStudentByGrade(const void *v1, const void *v2)
{
    student *s1 = (student *)v1;
    student *s2 = (student *)v2;
    return comparInt(s1->finalGrade, s2->finalGrade);
}

int compareProfById(const void *v1, const void *v2)
{
    prof *p1 = (prof *)v1;
    prof *p2 = (prof *)v2;
    return comparInt(p1->id, p2->id);
}

int compareProfByAge(const void *v1, const void *v2)
{
    prof *p1 = (prof *)v1;
    prof *p2 = (prof *)v2;
    return comparInt(p1->age, p2->age);
}

int compareProfByRank(const void *v1, const void *v2)
{
    prof *p1 = (prof *)v1;
    prof *p2 = (prof *)v2;
    return comparInt(p1->ra, p2->ra);
}

student *new_student(char *sName, int id, int age, int finalGrade)
{
    student *s = (student *)malloc(sizeof(student));
    s->sName = strdup(sName);
    s->id = id;
    s->age = age;
    s->finalGrade = finalGrade;
    return s;
}

prof *new_prof(int id, char *pName, int age, enum rank ra, int mi, int son)
{
    prof *p = (prof *)malloc(sizeof(prof));
    p->id = id;
    p->pName = strdup(pName);
    p->age = age;
    p->ra = ra;
    p->minA.min = mi;
    p->son.seniorOrNot = son;

    return p;
}

void addStudent(student *s)
{
    if (counterS < SIZE_STUDENT)
    {
        students[counterS++] = s;
    }
    else
        printf("no more place!\n");
}

void addProf(prof *p)
{
    if (counterP < SIZE_PROFF)
    {
        proffs[counterP++] = p;
    }
    else
        printf("no more place!\n");
}

int chooseAnOption()
{
    int x;
    printf("choose a num -option from the following:\n");
    printf("option num 1 - adding a student:\n");
    printf("option num 2 - choose a type of sorting for a student: sort by name,sort by age,sort by grade \n");
    printf("option num 3 - add a professor:\n");
    printf("option num 4 - choose a type of sorting for a professor: sort by id,age or rank \n");
    scanf("%d", &x);
    return x;
}
void sortTypeStudent()
{
    int type;
    printf("choose a num,1:name,2:age,3:grade\n");
    scanf("%d", &type);
    switch (type)
    {
    case 1:
        mergeSort(students, counterS, sizeof(student *), compareStudentByName);
        //printStudentArray();
        break;
    case 2:
        mergeSort(students, SIZE_STUDENT, sizeof(student *), compareStudentByAge);
        break;
    case 3:
        mergeSort(students, SIZE_STUDENT, sizeof(student *), compareStudentByGrade);
        break;
    default:
        printf("you chose wrong number!\n");
        break;
    }
    //printf("im here\n");
    printStudentArray();
}

void sortTypeProff()
{
    int type;
    printf("choose type of sorting for a professor,1:id,2:age,3:rank\n");
    scanf("%d", &type);
    switch (type)
    {
    case 1:
        mergeSort(proffs, counterP, sizeof(prof *), compareProfById);
        break;
    case 2:
        mergeSort(proffs, SIZE_PROFF, sizeof(prof *), compareProfByAge);
        break;
    case 3:
        mergeSort(proffs, SIZE_PROFF, sizeof(prof *), compareProfByRank);
        break;
    default:
        printf("you chose wrong number!\n");
        break;
    }
    printProffArray();
}

int main()
{
    student *s1 = new_student("Yael", 207, 20, 98);
    student *s2 = new_student("Yinon", 307, 23, 100);
    student *s3 = new_student("Hadar", 556, 25, 80);
    prof *p1 = new_prof(995, "Liora", 24, senior, 1, 1);
    prof *p2 = new_prof(0012, "Daniel", 8, lecture, 0, 0);

    addStudent(s1);
    addStudent(s2);
    addStudent(s3);
    addProf(p1);
    addProf(p2);
    // (void *base, size_t numberOfItems, size_t sizeOfItem, int (*compar)(const void *, const void *))
    //  printProffArray();
    //  mergeSort(proffs, counterP, sizeof(prof *), compareProfById);
    //  printProffArray();
    bool running = true;
    while (running)
    {
        int x = chooseAnOption();
        char name[256] = {0};
        int id, age, grade;
        enum rank ran;
        int min, son;
        int minAminian, senior;
        switch (x)
        {
        case 1:
            printf("enter details of a student(name id age grade)");
            scanf("%s %d %d %d", &name, &id, &age, &grade);
            student *s = new_student(name, id, age, grade);
            addStudent(s);
            break;
        case 2:
            sortTypeStudent();
            break;
        case 3:
            printf("enter details of a professor(name,age,rank,minAminian(1 or 0),senior or not(1 or 0) and id");
            scanf("%s %d %d %d %d", &name, &age, &ran, &minAminian, &senior, &id); // grade represents min aminian or not(0 or 1), id for senior or not
            prof *p = new_prof(id, name, age, ran, minAminian, senior);
            addProf(p);
            break;
        case 4:
            sortTypeProff();
            break;
        default:
            running = false;
            break;
        }
    }

    return 0;
}
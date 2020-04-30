#include <stdio.h>

struct minAminian
{
    unsigned int min : 1;         //min aminian or not
    unsigned int seniorOrNot : 1; // senior or not
};
enum rank
{
    proff,
    lecture,
    senior
};
typedef struct prof
{
    int id;
    char *pName;
    int age;
    enum rank ra;
    struct minAminian minA; //min aminian or not(1 or 0)
    struct minAminian son;  //senior or not(1 or 0)

} prof;

#include <stdio.h>
#include <string.h>
#define INPUT_SIZE 4
#define INDEXES_SIZE 16
#define WORD_SIZE 17 /*null byte at the end of the word*/

int isWord(char s[])
{
    return !strcmp(s, "cat") |
           !strcmp(s, "cats") |
           !strcmp(s, "tram") |
           !strcmp(s, "trams") |
           !strcmp(s, "tame") |
           !strcmp(s, "car") |
           !strcmp(s, "cars") |
           !strcmp(s, "rat") |
           !strcmp(s, "rats") |
           !strcmp(s, "ramp") |
           !strcmp(s, "art") |
           !strcmp(s, "cart") |
           !strcmp(s, "stamp") |
           !strcmp(s, "taken") |
           !strcmp(s, "men") |
           !strcmp(s, "make") |
           !strcmp(s, "take") |
           !strcmp(s, "ate") |
           !strcmp(s, "sell") |
           !strcmp(s, "steel") |
           !strcmp(s, "rake");
}
int isExist(int indexesArray[2][INDEXES_SIZE], int i, int j)
{
    for (int k = 0; k < INDEXES_SIZE; k++)
    {
        if (indexesArray[0][k] == i && indexesArray[1][k] == j)
            return 1;
    }
    /* wasn't found */
    return 0;
}
void printWord(char matrix[INPUT_SIZE][INPUT_SIZE], int loc, int indexesArray[2][INDEXES_SIZE])
{
    char word[WORD_SIZE] = {0};
    for (int i = 0; i <= loc; i++)
        word[i] = matrix[indexesArray[0][i]][indexesArray[1][i]];
    if (isWord(word))
        printf("%s\n", word);
}
int inBound(int start, int i, int end)
{
    return 0 <= i && i < end;
}
void findWords(char matrix[INPUT_SIZE][INPUT_SIZE], int i, int j, int loc, int indexesArray[2][INDEXES_SIZE])
{
    if (loc >= INDEXES_SIZE)
        return;
    if (isExist(indexesArray, i, j))
        return;
    if (!inBound(0, i, INPUT_SIZE) || !inBound(0, j, INPUT_SIZE))
        return;
    /**/
    indexesArray[0][loc] = i;
    indexesArray[1][loc] = j;

    printWord(matrix, loc, indexesArray);
    /* recursive calls*/
    findWords(matrix, i, j + 1, loc + 1, indexesArray); /*right*/
    findWords(matrix, i - 1, j, loc + 1, indexesArray); /*up*/
    findWords(matrix, i, j - 1, loc + 1, indexesArray); /*left*/
    findWords(matrix, i + 1, j, loc + 1, indexesArray); /*down*/
    /* back tracting*/
    indexesArray[0][loc] = -1;
    indexesArray[1][loc] = -1;
}
int main()
{
    int loc = 0;
    int indexesArray[2][INDEXES_SIZE] = {-1};
    /*char matrix[INPUT_SIZE][INPUT_SIZE] = {{'c', 'a', 'r', 't'},
                                           {'e', 't', 'a', 'k'},
                                           {'e', 's', 'm', 'e'},
                                           {'l', 'l', 'p', 'n'}};*/
    char matrix[INPUT_SIZE][INPUT_SIZE] = {'c', 'a', 'r', 't',
                                           'e', 't', 'a', 'k',
                                           'e', 's', 'm', 'e',
                                           'l', 'l', 'p', 'n'};
    for (int i = 0; i < INPUT_SIZE; i++)
    {
        for (int j = 0; j < INPUT_SIZE; j++)
        {
            findWords(matrix, i, j, loc, indexesArray);
        }
    }
    return 0;
}

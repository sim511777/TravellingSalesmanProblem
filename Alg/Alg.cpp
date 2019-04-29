// Alg.cpp : DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "Alg.h"

ALG_API int Add(int a, int b) {
    return a + b;
}

__int64 CalcRouteDistLong(int* order, int num, __int64* distTable) {
    __int64 fullDist = 0;
    for (int i = 0; i < num; i++) {
        int ptIdx = order[i];
        int ptIdxNext = order[(i+1) % num];
        fullDist += distTable[ptIdx * num + ptIdxNext];
    }
    return fullDist;
}

void Swap2Opt(int* route, int start, int end) {
    for (int i=start, j=end; i<j; i++, j--) {
        int temp = route[i];
        route[i] = route[j];
        route[j] = temp;
    }
}

void Improve2Opt(int* visitOrder, int num, __int64* distTable) {
    int* bestRoute = new int[num];
    memcpy(bestRoute, visitOrder, num * sizeof(int));
    __int64 bestDistance = CalcRouteDistLong(bestRoute, num, distTable);

    bool improved;
    do {
        improved = false;
        for (int i = 1; i < num - 1; i++) {
            for (int j = i + 1; j < num; j++) {
                __int64 newDistance = bestDistance
                    - distTable[bestRoute[i] * num + bestRoute[i-1]]
                    - distTable[bestRoute[j] * num + bestRoute[(j+1) % num]]
                    + distTable[bestRoute[j] * num + bestRoute[i-1]]
                    + distTable[bestRoute[i] * num + bestRoute[(j+1) % num]];
                if (newDistance < bestDistance) {
                    bestDistance = newDistance;
                    Swap2Opt(bestRoute, i, j);
                    improved = true;
                    break;
                }
            }
            if (improved)
                break;
        }
    } while (improved);

    memcpy(visitOrder, bestRoute, num * sizeof(int));
	 delete[] bestRoute;
}
// Alg.cpp : DLL 응용 프로그램을 위해 내보낸 함수를 정의합니다.
//

#include "stdafx.h"
#include "Alg.h"

ALG_API int Add(int a, int b) {
    return a + b;
}

float CalcRouteDist(int* order, int num, __int64* dists) {
    __int64 fullDist = 0;
    for (int i = 0; i < num; i++) {
        int ptIdx = order[i];
        int ptIdxNext = order[(i+1) % num];
        fullDist += dists[ptIdx * num + ptIdxNext];
    }
    return fullDist * 0.001f ;
}

void _2OptSwap(int* existing_route, int* new_route, int num, int start, int end) {
    for (int i=0; i<start; i++)
        new_route[i] = existing_route[i];
    for (int i=start; i<=end; i++)
        new_route[i] = existing_route[end-(i-start)];
    for (int i=end+1; i<num; i++)
        new_route[i] = existing_route[i];
}

ALG_API void Improve2Opt(int* visitOrder, int num, __int64* dists) {
    int* existing_route = new int[num];
    memcpy(existing_route, visitOrder, num * sizeof(int));
    int* new_route = new int[num];

start_again:
    float best_distance = CalcRouteDist(existing_route, num, dists);
    for (int i = 1; i < num - 1; i++) {
        for (int j = i + 1; j < num; j++) {
            _2OptSwap(existing_route, new_route, num, i, j);
            float new_distance = CalcRouteDist(new_route, num, dists);
            if (new_distance < best_distance) {
                int* temp = existing_route;
                existing_route = new_route;
                new_route = temp;
                goto start_again;
            }
        }
    }

    memcpy(visitOrder, existing_route, num * sizeof(int));
	
	delete[] existing_route;
	delete[] new_route;
}

__int64 CalcRouteDistLong(int* order, int num, __int64* dists) {
    __int64 fullDist = 0;
    for (int i = 0; i < num; i++) {
        int ptIdx = order[i];
        int ptIdxNext = order[(i+1) % num];
        fullDist += dists[ptIdx * num + ptIdxNext];
    }
    return fullDist;
}

void _2OptSwapSelf(int* route, int start, int end) {
    for (int i=start, j=end; i<j; i++, j--) {
        int temp = route[i];
        route[i] = route[j];
        route[j] = temp;
    }
}

void Improve2OptNew(int* visitOrder, int num, __int64* dists) {
    int* best_route = new int[num];
    memcpy(best_route, visitOrder, num * sizeof(int));
    __int64 best_distance = CalcRouteDistLong(best_route, num, dists);

start_again:
    for (int i = 1; i < num - 1; i++) {
        for (int j = i + 1; j < num; j++) {
            long new_distance = best_distance
                - dists[best_route[i] * num + best_route[i-1]]
                - dists[best_route[j] * num + best_route[(j+1) % num]]
                + dists[best_route[j] * num + best_route[i-1]]
                + dists[best_route[i] * num + best_route[(j+1) % num]];
            if (new_distance < best_distance) {
                best_distance = new_distance;
                _2OptSwapSelf(best_route, i, j);
                goto start_again;
            }
        }
    }

    memcpy(visitOrder, best_route, num * sizeof(int));
	delete[] best_route;
}
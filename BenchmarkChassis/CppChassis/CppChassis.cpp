#include <iostream>
#include <chrono>
#include "Timer.hpp"

int main()
{
    Timer timer = Timer();
    int upperBound = 10000000;

    int counter = 0;
    timer.start();

    while (counter < upperBound)
    {
        counter++;
    }

    timer.stop();

    std::cout << counter << " iterations took: " << timer.elapsedMilliseconds() <<"ms\n";
}

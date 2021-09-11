#include <iostream>
#include <chrono>
#include <ctime>
#include <cmath>

class Timer
{
public:
    void start();
    void stop();
    double elapsedMilliseconds();
    double elapsedNanoseconds();
    double elapsedSeconds();
private:
    long fibonacci(unsigned n);

    std::chrono::time_point<std::chrono::system_clock> m_StartTime;
    std::chrono::time_point<std::chrono::system_clock> m_EndTime;
    bool                                               m_bRunning = false;
};
cmake_minimum_required(VERSION 3.24)
project(cardGames)

set(CMAKE_CXX_STANDARD 17)

add_executable(cardGames main.cpp)

add_subdirectory(deckLib)
add_subdirectory(cardGamesLib)

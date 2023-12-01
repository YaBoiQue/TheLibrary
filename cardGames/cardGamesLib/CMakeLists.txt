cmake_minimum_required(VERSION 3.24)
project(cardGamesLib)

add_subdirectory(war)
add_subdirectory(solitaire)

set(CMAKE_CXX_STANDARD 17)

add_executable(cardGamesLib cardGamesLib.cpp)
link_directories(cardGamesLib ${CMAKE_CURRENT_LIST_DIR}/../lib)
link_directories(cardGamesLib ${CMAKE_CURRENT_LIST_DIR}/lib)
target_link_libraries(cardGamesLib deckLib warLib solitaireLib)
target_include_directories(cardGamesLib PUBLIC ${CMAKE_CURRENT_LIST_DIR}/../include)
target_include_directories(cardGamesLib PUBLIC ${CMAKE_CURRENT_LIST_DIR}/include)
target_include_directories(cardGamesLib PUBLIC ${CMAKE_CURRENT_LIST_DIR})

#add_custom_command(TARGET cardGamesLib
#        PRE_BUILD
#        COMMAND ${CMAKE_COMMAND} -E copy ${CMAKE_CURRENT_LIST_DIR}/../include/deckLib.h ${CMAKE_CURRENT_LIST_DIR}/include/)

#add_custom_command(TARGET cardGamesLib
#        PRE_LINK
#        COMMAND ${CMAKE_COMMAND} -E copy  ${CMAKE_CURRENT_LIST_DIR}/../lib/libdeckLib.* ${CMAKE_CURRENT_LIST_DIR}/lib/)

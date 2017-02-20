#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// System.String
struct String_t;
// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.Material
struct Material_t193706927;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.GameObject[]
struct GameObjectU5BU5D_t3057952154;

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Generator.GameCreator
struct  GameCreator_t1744592376  : public MonoBehaviour_t1158329972
{
public:
	// System.Int32 Generator.GameCreator::width
	int32_t ___width_2;
	// System.Int32 Generator.GameCreator::height
	int32_t ___height_3;
	// System.String Generator.GameCreator::seed
	String_t* ___seed_4;
	// System.Int32 Generator.GameCreator::circleCount
	int32_t ___circleCount_5;
	// UnityEngine.Sprite Generator.GameCreator::circle
	Sprite_t309593783 * ___circle_6;
	// UnityEngine.Sprite Generator.GameCreator::background
	Sprite_t309593783 * ___background_7;
	// UnityEngine.Material Generator.GameCreator::lineMaterial
	Material_t193706927 * ___lineMaterial_8;
	// UnityEngine.GameObject Generator.GameCreator::board
	GameObject_t1756533147 * ___board_9;
	// UnityEngine.GameObject Generator.GameCreator::BG
	GameObject_t1756533147 * ___BG_10;
	// UnityEngine.GameObject[] Generator.GameCreator::circles
	GameObjectU5BU5D_t3057952154* ___circles_11;
	// UnityEngine.GameObject[] Generator.GameCreator::lines
	GameObjectU5BU5D_t3057952154* ___lines_12;

public:
	inline static int32_t get_offset_of_width_2() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___width_2)); }
	inline int32_t get_width_2() const { return ___width_2; }
	inline int32_t* get_address_of_width_2() { return &___width_2; }
	inline void set_width_2(int32_t value)
	{
		___width_2 = value;
	}

	inline static int32_t get_offset_of_height_3() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___height_3)); }
	inline int32_t get_height_3() const { return ___height_3; }
	inline int32_t* get_address_of_height_3() { return &___height_3; }
	inline void set_height_3(int32_t value)
	{
		___height_3 = value;
	}

	inline static int32_t get_offset_of_seed_4() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___seed_4)); }
	inline String_t* get_seed_4() const { return ___seed_4; }
	inline String_t** get_address_of_seed_4() { return &___seed_4; }
	inline void set_seed_4(String_t* value)
	{
		___seed_4 = value;
		Il2CppCodeGenWriteBarrier(&___seed_4, value);
	}

	inline static int32_t get_offset_of_circleCount_5() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___circleCount_5)); }
	inline int32_t get_circleCount_5() const { return ___circleCount_5; }
	inline int32_t* get_address_of_circleCount_5() { return &___circleCount_5; }
	inline void set_circleCount_5(int32_t value)
	{
		___circleCount_5 = value;
	}

	inline static int32_t get_offset_of_circle_6() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___circle_6)); }
	inline Sprite_t309593783 * get_circle_6() const { return ___circle_6; }
	inline Sprite_t309593783 ** get_address_of_circle_6() { return &___circle_6; }
	inline void set_circle_6(Sprite_t309593783 * value)
	{
		___circle_6 = value;
		Il2CppCodeGenWriteBarrier(&___circle_6, value);
	}

	inline static int32_t get_offset_of_background_7() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___background_7)); }
	inline Sprite_t309593783 * get_background_7() const { return ___background_7; }
	inline Sprite_t309593783 ** get_address_of_background_7() { return &___background_7; }
	inline void set_background_7(Sprite_t309593783 * value)
	{
		___background_7 = value;
		Il2CppCodeGenWriteBarrier(&___background_7, value);
	}

	inline static int32_t get_offset_of_lineMaterial_8() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___lineMaterial_8)); }
	inline Material_t193706927 * get_lineMaterial_8() const { return ___lineMaterial_8; }
	inline Material_t193706927 ** get_address_of_lineMaterial_8() { return &___lineMaterial_8; }
	inline void set_lineMaterial_8(Material_t193706927 * value)
	{
		___lineMaterial_8 = value;
		Il2CppCodeGenWriteBarrier(&___lineMaterial_8, value);
	}

	inline static int32_t get_offset_of_board_9() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___board_9)); }
	inline GameObject_t1756533147 * get_board_9() const { return ___board_9; }
	inline GameObject_t1756533147 ** get_address_of_board_9() { return &___board_9; }
	inline void set_board_9(GameObject_t1756533147 * value)
	{
		___board_9 = value;
		Il2CppCodeGenWriteBarrier(&___board_9, value);
	}

	inline static int32_t get_offset_of_BG_10() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___BG_10)); }
	inline GameObject_t1756533147 * get_BG_10() const { return ___BG_10; }
	inline GameObject_t1756533147 ** get_address_of_BG_10() { return &___BG_10; }
	inline void set_BG_10(GameObject_t1756533147 * value)
	{
		___BG_10 = value;
		Il2CppCodeGenWriteBarrier(&___BG_10, value);
	}

	inline static int32_t get_offset_of_circles_11() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___circles_11)); }
	inline GameObjectU5BU5D_t3057952154* get_circles_11() const { return ___circles_11; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_circles_11() { return &___circles_11; }
	inline void set_circles_11(GameObjectU5BU5D_t3057952154* value)
	{
		___circles_11 = value;
		Il2CppCodeGenWriteBarrier(&___circles_11, value);
	}

	inline static int32_t get_offset_of_lines_12() { return static_cast<int32_t>(offsetof(GameCreator_t1744592376, ___lines_12)); }
	inline GameObjectU5BU5D_t3057952154* get_lines_12() const { return ___lines_12; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_lines_12() { return &___lines_12; }
	inline void set_lines_12(GameObjectU5BU5D_t3057952154* value)
	{
		___lines_12 = value;
		Il2CppCodeGenWriteBarrier(&___lines_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

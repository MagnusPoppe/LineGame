#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

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

// ClickManager
struct  ClickManager_t4152430967  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean ClickManager::heldWithMouse
	bool ___heldWithMouse_2;
	// UnityEngine.GameObject ClickManager::held
	GameObject_t1756533147 * ___held_3;
	// UnityEngine.GameObject[] ClickManager::childLines
	GameObjectU5BU5D_t3057952154* ___childLines_4;

public:
	inline static int32_t get_offset_of_heldWithMouse_2() { return static_cast<int32_t>(offsetof(ClickManager_t4152430967, ___heldWithMouse_2)); }
	inline bool get_heldWithMouse_2() const { return ___heldWithMouse_2; }
	inline bool* get_address_of_heldWithMouse_2() { return &___heldWithMouse_2; }
	inline void set_heldWithMouse_2(bool value)
	{
		___heldWithMouse_2 = value;
	}

	inline static int32_t get_offset_of_held_3() { return static_cast<int32_t>(offsetof(ClickManager_t4152430967, ___held_3)); }
	inline GameObject_t1756533147 * get_held_3() const { return ___held_3; }
	inline GameObject_t1756533147 ** get_address_of_held_3() { return &___held_3; }
	inline void set_held_3(GameObject_t1756533147 * value)
	{
		___held_3 = value;
		Il2CppCodeGenWriteBarrier(&___held_3, value);
	}

	inline static int32_t get_offset_of_childLines_4() { return static_cast<int32_t>(offsetof(ClickManager_t4152430967, ___childLines_4)); }
	inline GameObjectU5BU5D_t3057952154* get_childLines_4() const { return ___childLines_4; }
	inline GameObjectU5BU5D_t3057952154** get_address_of_childLines_4() { return &___childLines_4; }
	inline void set_childLines_4(GameObjectU5BU5D_t3057952154* value)
	{
		___childLines_4 = value;
		Il2CppCodeGenWriteBarrier(&___childLines_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

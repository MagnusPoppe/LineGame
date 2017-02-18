#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// UnityEngine.Sprite
struct Sprite_t309593783;
// UnityEngine.Material
struct Material_t193706927;

#include "mscorlib_System_Object2689449295.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Generator.GraphicsCreator
struct  GraphicsCreator_t377418159  : public Il2CppObject
{
public:
	// UnityEngine.Sprite Generator.GraphicsCreator::circle
	Sprite_t309593783 * ___circle_4;
	// UnityEngine.Sprite Generator.GraphicsCreator::background
	Sprite_t309593783 * ___background_5;
	// UnityEngine.Material Generator.GraphicsCreator::lineMaterial
	Material_t193706927 * ___lineMaterial_6;

public:
	inline static int32_t get_offset_of_circle_4() { return static_cast<int32_t>(offsetof(GraphicsCreator_t377418159, ___circle_4)); }
	inline Sprite_t309593783 * get_circle_4() const { return ___circle_4; }
	inline Sprite_t309593783 ** get_address_of_circle_4() { return &___circle_4; }
	inline void set_circle_4(Sprite_t309593783 * value)
	{
		___circle_4 = value;
		Il2CppCodeGenWriteBarrier(&___circle_4, value);
	}

	inline static int32_t get_offset_of_background_5() { return static_cast<int32_t>(offsetof(GraphicsCreator_t377418159, ___background_5)); }
	inline Sprite_t309593783 * get_background_5() const { return ___background_5; }
	inline Sprite_t309593783 ** get_address_of_background_5() { return &___background_5; }
	inline void set_background_5(Sprite_t309593783 * value)
	{
		___background_5 = value;
		Il2CppCodeGenWriteBarrier(&___background_5, value);
	}

	inline static int32_t get_offset_of_lineMaterial_6() { return static_cast<int32_t>(offsetof(GraphicsCreator_t377418159, ___lineMaterial_6)); }
	inline Material_t193706927 * get_lineMaterial_6() const { return ___lineMaterial_6; }
	inline Material_t193706927 ** get_address_of_lineMaterial_6() { return &___lineMaterial_6; }
	inline void set_lineMaterial_6(Material_t193706927 * value)
	{
		___lineMaterial_6 = value;
		Il2CppCodeGenWriteBarrier(&___lineMaterial_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

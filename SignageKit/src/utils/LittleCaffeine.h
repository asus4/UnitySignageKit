//
//  LittleCaffeine.h
//
//  This is tiny utility inspired by Caffeine http://lightheadsw.com/caffeine/
//
//  Created by Koki Ibukuro on 2014/04/01.
//  Copyright (c) 2014年 Koki Ibukuro. All rights reserved.
//

#pragma once

#ifndef Little_Caffeine_h
#define Little_Caffeine_h

#import <Foundation/Foundation.h>
#import <IOKit/pwr_mgt/IOPMLib.h>

static IOPMAssertionID LittleCaffeineAssertionID;

static BOOL LittleCaffeineEnable() {
    
    // https://developer.apple.com/library/mac/qa/qa1340/_index.html
    
    CFStringRef reasonForActivity= CFSTR("Little Caffeine for Wake Up");
    IOReturn success = IOPMAssertionCreateWithName(kIOPMAssertionTypeNoDisplaySleep,
                                                   kIOPMAssertionLevelOn, reasonForActivity, &LittleCaffeineAssertionID);

    if (success == kIOReturnSuccess) {
        return YES;
    }
    else {
        LittleCaffeineAssertionID = -1;
        return NO;
    }
}

static BOOL LittleCaffeineDisable() {
    IOReturn success = NO;
    if(LittleCaffeineAssertionID > 0) {
        success = IOPMAssertionRelease(LittleCaffeineAssertionID);
    }
    
    if(success == kIOReturnSuccess) {
        return YES;
    }
    else {
        return NO;
    }
}

#endif

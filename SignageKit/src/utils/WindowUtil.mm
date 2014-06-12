//
//  WindowUtil.m
//  SignageKit
//
//  Created by Koki Ibukuro on 6/11/14.
//  Copyright (c) 2014 Koki Ibukuro. All rights reserved.
//

#import "WindowUtil.h"
#import "LittleCaffeine.h"
#import <CoreServices/CoreServices.h>

@implementation WindowUtil

//#define _keyWindow [NSApp keyWindow]
#define _keyWindow [[NSApplication sharedApplication] mainWindow]

+ (bool) isMervericsOrLater {
    return NSAppKitVersionNumber > NSAppKitVersionNumber10_8;
}

+ (void) barShow:(bool)show {
    dispatch_async(dispatch_get_main_queue(), ^{
        if(show) {
            [_keyWindow setStyleMask: (NSTitledWindowMask | NSClosableWindowMask | NSMiniaturizableWindowMask | NSResizableWindowMask) ];
        }
        else {
            [_keyWindow setStyleMask: NSBorderlessWindowMask];
        }
    });
}

+ (void) menuShow:(bool)show {
    dispatch_async(dispatch_get_main_queue(), ^{
        [NSMenu setMenuBarVisible:show];
    });
}

+ (void) setFrontScreen:(bool)isfront {
    if(isfront) {
        [_keyWindow setLevel:kCGScreenSaverWindowLevel];
    }
    else {
        [_keyWindow setLevel:kCGNormalWindowLevel];
    }
}

+ (unsigned long) screenCount {
    return [[NSScreen screens] count];
}

+ (void) windowPosition:(NSRect)rect {
    dispatch_async(dispatch_get_main_queue(), ^{
        [_keyWindow setFrame:rect display:NO];
    });
}

+ (void) fullAtScreen:(uint)index {
    const NSArray* screens = [NSScreen screens];
    if(index >= screens.count) {
//        NSException *ex = [NSException exceptionWithName:NSRangeException reason:@"Screen range exception" userInfo:nil];
//        @throw ex;
        index = (uint) screens.count - 1;
    }
    const NSScreen *screen = [screens objectAtIndex:index]; // for 32bit code
    [WindowUtil windowPosition:screen.frame];
}

+ (void) fullAllScreen {
    if([WindowUtil isMervericsOrLater]) {
        if(NSScreen.screensHaveSeparateSpaces) {
            // TODO : Aleat
            NSLog(@"Change setting screens have separate spaces");
        }
        // make union rect
        NSRect union_rect;
        for (NSScreen* screen in [NSScreen screens]) {
            union_rect = NSUnionRect(union_rect, screen.frame);
        }
        [WindowUtil windowPosition:union_rect];
    }
    
}

@end

#pragma mark -
#pragma mark externs

extern "C" {
    void unity_windowBarShow (bool show) {
        [WindowUtil barShow:show];
    }
    
    void unity_menuShow (bool show) {
        [WindowUtil menuShow:show];
    }
    
    void unity_setFrontScreen(bool isfront) {
        dispatch_async(dispatch_get_main_queue(), ^{
            [WindowUtil setFrontScreen:isfront];
        });
        
    }
    
    void unity_littleCaffeine(bool isOn) {
        if(isOn) {
            LittleCaffeineEnable();
        } else {
            LittleCaffeineDisable();
        }
    }
    
    void unity_windowPosition(float x, float y, float w, float h) {
        [WindowUtil windowPosition:NSMakeRect(x, y, w, h)];
    }
    
    void unity_fullAtScreen(uint index) {
        [WindowUtil fullAtScreen:index];
    }
    
    void unity_fullAllScreen(void) {
        [WindowUtil fullAllScreen];
    }
}
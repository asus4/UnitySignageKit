//
//  AppDelegate.m
//  MacSignageKit
//
//  Created by Koki Ibukuro on 6/11/14.
//  Copyright (c) 2014 Koki Ibukuro. All rights reserved.
//

#import "AppDelegate.h"
#import "LittleCaffeine.h"


#pragma mark externs
extern void unity_windowBarShow(bool);
extern void unity_menuShow(bool);
extern void unity_windowPosition(float, float, float, float);
extern void unity_setFrontScreen(bool);
extern void unity_fullAtScreen(uint);
extern void unity_fullAllScreen(void);

@implementation AppDelegate

- (void)applicationDidFinishLaunching:(NSNotification *)aNotification
{
    // Insert code here to initialize your application
}

- (IBAction)onNeverSleepClick:(NSButton *)sender {
    if(sender.state == NSOnState) {
        LittleCaffeineEnable();
    }
    else {
        LittleCaffeineDisable();
    }
}

- (IBAction)onBarHideClick:(NSButton *)sender {
    if(sender.state == NSOnState) {
        unity_windowBarShow(false);
        unity_menuShow(false);
    }
    else {
        unity_windowBarShow(true);
        unity_menuShow(true);
    }
}

- (IBAction)onWindow1Click:(id)sender {
    unity_fullAtScreen(0);
    unity_setFrontScreen(true);
}

- (IBAction)onWindow2Click:(id)sender {
    unity_fullAtScreen(1);
    unity_setFrontScreen(true);
}

- (IBAction)onWindowsFillClick:(id)sender {
    unity_fullAllScreen();
    unity_setFrontScreen(true);
}

- (IBAction)onWindowCustomClick:(id)sender {
    unity_windowPosition(10, 10, 500, 300);
}

@end
